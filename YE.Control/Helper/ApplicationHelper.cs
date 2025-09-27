using System;
using System.Threading.Tasks;
using YE.Control.MessageBox;

namespace YE.Control.Helper
{
    public class ApplicationHelper
    {
        public ApplicationHelper(IMessageBoxService _messageBoxService, string _assemblyGUID)
        {
            messageBoxService = _messageBoxService;

            assemblyGUID = _assemblyGUID;
        }

        #region readonly Field

        private readonly IMessageBoxService messageBoxService;

        private readonly string assemblyGUID;

        #endregion


        #region Method

        public bool OnStartup()
        {
            if (!EnsureAssemblySingletion())
            {
                messageBoxService?.ShowMessage(
                    $"{System.Reflection.Assembly.GetEntryAssembly().GetName().Name} 服务实例已在运行中。",
                    MessageLevel.Information
                );

                System.Windows.Application.Current.Shutdown();

                return false;
            }

            /// 设置UI线程发生异常时处理函数
            System.Windows.Application.Current.DispatcherUnhandledException +=
                App_DispatcherUnhandledException;

            /// 设置非UI线程发生异常时处理函数
            AppDomain.CurrentDomain.UnhandledException += App_UnhandledException;

            /// 设置托管代码异步线程发生异常时处理函数
            TaskScheduler.UnobservedTaskException += App_UnobservedTaskException;

            /// 设置非托管代码发生异常时处理函数
            callBack = new Unhandled_CallBack(Unhandled_ExceptionFilter);
            SetUnhandledExceptionFilter(callBack);

            return true;
        }

        public void OnExit()
        {
            mutex.Dispose();
            mutex = null;
        }

        #endregion


        #region Singletion App

        /// <summary>
        /// 必须定义此变量
        /// </summary>
        /// <remarks>
        /// <para>
        /// 当<see cref="EnsureAssemblySingletion()"/>内部定义局部Mutex时，如果先启动软件再调试运行，此时判断单例模式失效。
        /// </para>
        /// </remarks>
        private System.Threading.Mutex mutex;

        private bool EnsureAssemblySingletion()
        {
            mutex = new System.Threading.Mutex(
                true,
                $"{System.Reflection.Assembly.GetEntryAssembly().GetName().Name} - {assemblyGUID}",
                out bool ret
            );
            if (ret)
            {
                mutex.ReleaseMutex();
            }
            return ret;
        }

        #endregion


        #region Try catch Exception

        private void App_DispatcherUnhandledException(
            object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs exception
        )
        {
            messageBoxService.ShowException(exception.Exception, ExceptionType._UI);

            exception.Handled = true;
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs exception)
        {
            messageBoxService.ShowException(
                exception.ExceptionObject as Exception,
                ExceptionType._非UI
            );

            if (exception.IsTerminating)
            {
                messageBoxService.ShowMessage("软件出现不可恢复错误，即将关闭。", MessageLevel.Error);

                Environment.Exit(0);
            }
        }

        private void App_UnobservedTaskException(
            object sender,
            UnobservedTaskExceptionEventArgs exception
        )
        {
            if (exception.Observed == false && exception.Exception != null)
            {
                foreach (var ex in exception.Exception.Flatten().InnerExceptions)
                {
                    messageBoxService.ShowException(ex, ExceptionType._Task);
                }
                exception.SetObserved();
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern Int32 SetUnhandledExceptionFilter(Unhandled_CallBack cb);

        private delegate int Unhandled_CallBack(ref long a);

        private Unhandled_CallBack callBack;

        private int Unhandled_ExceptionFilter(ref long a)
        {
            messageBoxService.ShowException(
                new Exception($"StackTrace = {Environment.StackTrace}"),
                ExceptionType._非托管代码
            );

            return 1;
        }

        #endregion
    }
}
