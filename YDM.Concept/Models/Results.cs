namespace YDM.Concept.Models
{
    class Results<T>
    {
        public string Exception { get; set; }
        public T Result { get; set; }
        public bool Success { get; set; }
    }
}
