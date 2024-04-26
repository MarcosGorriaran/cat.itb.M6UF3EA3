

namespace cat.itb.M6UF3EA1.Models
{
    public class Address
    {
        //ATTRIBUTES
        public string building { get; set; }
        public double[] coord { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }


        //ToSTRING
        public override string ToString()
        {
            return "Building: " + building + "  Coord: " + coord + "   Street: " + street + "   Zipcode: " + zipcode;
        }
    }
}
