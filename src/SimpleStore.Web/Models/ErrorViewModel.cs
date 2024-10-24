namespace SimpleStore.Web.Models
{
    public class ErrorViewModel
    {
        /* Tinha um ? depois de string, não sei se era erro de digitação mas resolveu o erro quando tirei ele. */
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
