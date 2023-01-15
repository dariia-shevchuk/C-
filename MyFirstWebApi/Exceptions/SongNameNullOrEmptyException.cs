namespace MyFirstWebApi.Exceptions
{
    public class SongNameNullOrEmptyException : ApiExceptionBase
    {
        public override string Code => "title_empty_or_null";

        public SongNameNullOrEmptyException() 
            : base("Song title can't be null or empty")
        {
        }
    }
}
