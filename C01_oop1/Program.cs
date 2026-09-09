namespace C01_oop1
{
    internal class Program
    {
        #region DeliveryAddress
        public struct DeliveryAddress
        {
            public string City { set; get; }
            public string Street { set; get; }
            public int BuildingNumber { set; get; }

                


            DeliveryAddress(string city , string Street, int buildingNumber)
            {
                this.City = city;
                this.Street = Street;
                this.BuildingNumber = buildingNumber;
            }

            public string GetFullAddress()
            {
                return $"City : {City}\nStreet : {Street}\nBuilding Number : {BuildingNumber}\n";
            }
        }
        #endregion 

        static void Main(string[] args)
        {

            #region Part 01 : Theoretical Questions

            #region q1 
            //a) well the other variable will get the copy of value from the DeliveryAddress variable cuz we are here dealing with a struct 

            //b) the other variable well get the reference value from the Customer Variable cuz we are here dealinmg with a class so anything
            //affect the other variable will also affect the class variable . 

            #endregion


            #region q2 
            //a) 1- the access modifiers that are used is punlic .
            //2- there is no validation for the user input .
            //3- there is no properties to deal with the fielsd through (seters , geters) .


            //b) it will gave a limited access to the user on those fields .
            #endregion


            #endregion


            #region Part 02 : Practical
            #region 1) 
            //DeliveryAddress d1 = new DeliveryAddress();
            //d1.Street = "63-St";
            //string str = d1.Street;
            //str = "45-str";
            //Console.WriteLine(d1.Street);
            //Console.WriteLine(str);
            #endregion
            #endregion
        }
    }
}
