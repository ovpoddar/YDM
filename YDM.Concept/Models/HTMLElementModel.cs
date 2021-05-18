namespace YDM.Concept.Models
{
    internal class HTMLElementModel
    {
        public string Begin { get; }
        public string End { get; }
        public HTMLElementModel(string begin, string end)
        {
            Begin = begin;
            End = end;
        }
    }
}
