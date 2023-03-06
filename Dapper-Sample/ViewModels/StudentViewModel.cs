using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dapper_Sample.ViewModels
{
    public class StudentViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }

    }

    public class FuncResult
    {
        public Status Status { set; get; }
        public object ID { set; get; }
        public Error Error { set; get; }

        public object Entity { set; get; }
        public long? Total { set; get; }

    }


    public enum Status
    {
        Fail = 0,
        Ok = 1
    }
    public class Error
    {
        public string Code { set; get; }
        public string Message { set; get; }
        public string StackTrace { get; set; }

        public string InnerException { get; set; }
    }

}
