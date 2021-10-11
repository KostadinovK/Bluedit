namespace BlueditServer.Models.ResponseModels
{
    public class ErrorResponseModel
    {
        public string Error { get; set; }

        public int Code { get; set; }

        public ErrorResponseModel(string error, int code)
        {
            this.Error = error;
            this.Code = code;
        }
    }
}
