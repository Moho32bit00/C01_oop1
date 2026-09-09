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


        #region Shipment
        public struct Shipment
        {
            private string trackingCode;
            private string description;
            private decimal weight;
            private decimal deliveryFee;

            #region It should also contain a public property:
            //public DeliveryAddress Destination { get; set; }
            #endregion 

            #region Apply proper encapsulation using public properties with the following validation rules
            //public string TrackingCode
            //{
            //    get { return trackingCode; }
            //    set
            //    {
            //        if (value != null && value != "" && value != " ")
            //        {
            //            trackingCode = value;
            //        }
            //    }
            //}
            //public string Description
            //{
            //    get
            //    {
            //        return description;
            //    }
            //    set
            //    {
            //        if (value != null && value != "" && value != " ")
            //        {
            //            description = value;
            //        }
            //    }
            //}
            //public decimal DeliveryFee
            //{
            //    get { return deliveryFee; }

            //    set
            //    {
            //        if (value > 0)
            //        {
            //            deliveryFee = value;
            //        }
            //    }
            //}
            //public decimal Weight
            //{
            //    get { return weight; }

            //    set
            //    {
            //        if (value > 0)
            //        {
            //            weight = value;
            //        }
            //    }
            //}

            #endregion

            #region Add the following properties:

            public string TrackingCode { get; }

            public string Description
            {
                get
                {
                    return description;
                }
                set
                {
                    if (value != null && value != "" && value != " ")
                    {
                        description = value;
                    }
                }
            }

            public decimal Weight
            {
                get { return weight; }

                set
                {
                    if (value > 0)
                    {
                        weight = value;
                    }
                }
            }

            public decimal DeliveryFee
            {
                get { return deliveryFee; }

                private set
                {
                    if (value > 0)
                    {
                        deliveryFee = value;
                    }
                }
            }

            public DeliveryAddress Destination { get; set; }

            public decimal EstimatedCost {
                get {
                    return deliveryFee + (weight * 5) ;
                } 
            }
            #endregion

            #region Add constructor overloading to Shipment:
            Shipment(string trackingCode)
            {
                this.trackingCode= trackingCode;
                Description = "Unknown";
                Weight = 1;
                DeliveryFee = 50;
                Destination = new DeliveryAddress
                {
                    City = "Unknown",
                    Street = "Unknown",
                    BuildingNumber = 0
                };
            }
            Shipment(string trackingCode , string description , decimal weight , decimal deliveryFee , DeliveryAddress destination)
            {
                this.trackingCode=trackingCode;
                this.description=description;
                this.weight=weight;
                this.deliveryFee=deliveryFee;   
                Destination = destination;
            }

            #endregion


            #region Add the following methods to Shipment:
            public void UpdateDeliveryFee(decimal newFee)
            {
                if (newFee > 0)
                {
                    deliveryFee = newFee;
                }
            }

            public void PrintShipment()
            {
                Console.Write($"Distenation : \nCity : {Destination.City}\nStreet : {Destination.Street}\nBuilding Number : " +
                    $"{Destination.BuildingNumber}\nTracking Code : {trackingCode}\nDescription : {description}\nWeight : {weight}\nDelivery Fee : {deliveryFee}" +
                    $"estimated cost : {EstimatedCost}\n");
            }
            #endregion
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
