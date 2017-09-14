namespace Common
{
    public class Log
    {
        public static Log Inst;

        public static void Write(object message, object className)
        {
            Inst.WriteHandler(message, className);
        }

        public static void Warning(object message, object className)
        {
            Inst.WarningHandler(message, className);
        }

        public static void Error(object message, object className)
        {
            Inst.ErrorHandler(message, className);
        }

        protected virtual void WarningHandler(object message, object className)
        {
        }

        protected virtual void ErrorHandler(object message, object className)
        {
        }

        protected virtual void WriteHandler(object message, object className)
        {
        }
    }
}
