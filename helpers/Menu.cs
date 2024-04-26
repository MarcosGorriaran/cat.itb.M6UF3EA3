namespace cat.itb.M6UF3EA2.helpers
{
    public class Menu
    {
        private string title;
        private string askValueMsg;
        private Dictionary<string, string> elements;

        public Menu(string title,Dictionary<string,string> elements, string askValueMsg)
        {
            this.Title = Title;
            this.Elements = elements;
            this.AskValueMsg = askValueMsg;
        }
        public Menu (Dictionary<string, string> elements, string askValueMsg):this(string.Empty,elements,askValueMsg) { }
        public Menu (Dictionary<string, string> elements) :this(elements, string.Empty) {}
        public Menu ():this(new Dictionary<string, string>()) { }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string AskValueMsg
        {
            get { return askValueMsg; }
            set { askValueMsg = value; }
        }
        public Dictionary<string,string> Elements
        {
            get { return elements; }
            set { elements = value; }
        }
        
        public override string ToString()
        {
            string result = string.Empty;
            if (Title == string.Empty)
            {
                result += Title + Environment.NewLine;
            }
            foreach (KeyValuePair<string, string> element in Elements)
            {
                result += $"{element.Key}{element.Value}{Environment.NewLine}";
            }


            return result + AskValueMsg;
        }
        public string ToString(string spliterIndexElement)
        {
            string result = string.Empty;
            if (Title == string.Empty)
            {
                result += Title + Environment.NewLine;
            }
            foreach (KeyValuePair<string, string> element in Elements)
            {
                result += $"{element.Key}{spliterIndexElement}{element.Value}{Environment.NewLine}";
            }


            return result + AskValueMsg;
        }
    }
}
