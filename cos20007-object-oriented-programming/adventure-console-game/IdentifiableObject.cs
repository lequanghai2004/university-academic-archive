namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifier = new List<string>();
        public IdentifiableObject(string[] idents) 
        {
            _identifier.AddRange((idents.Select(ident => ident.ToLower())));
        }
        public virtual bool AreYou(string id)
        {
            return _identifier.Contains(id.ToLower());
        }
        public string FirstId()
        {
            if(_identifier.Count == 0) { return ""; }
            return _identifier[0];
        }
        public string SecondId()
        {
            if (_identifier[1] == null) { return ""; }
            return _identifier[1];
        }
        public void AddIdentifier(string id)
        {
            _identifier.Add(id.ToLower());
        }
    }
}
