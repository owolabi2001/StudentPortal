namespace StudentPortal.Dto.response
{
    public class GenericResponse
    {

        public GenericResponse(){ }
        public GenericResponse(string code,string message,Object data, Object MetaData)
        {
            Code = code;
            Message = message;
            Data = data;
            this.MetaData = MetaData;
            
        }

        public string Code { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
        public Object MetaData { get; set; }
    }
}
