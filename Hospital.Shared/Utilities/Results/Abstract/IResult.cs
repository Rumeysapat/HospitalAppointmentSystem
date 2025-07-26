using Hospital.Shared.Utilities.Results.ComplexTypes;

namespace Hospital.Shared.Utilities.Results.Abstract
{

    public interface IResult
    {
        public ResultStatus ResultStatus { get;}

        public string Message { get;  }

        public Exception Exception { get;  }
        


    }

   
}