namespace C01_oop1
{
    internal class Program
    {
        #region DeliveryAddress struct 
        public struct DeliveryAddress
        {
            public string City { set; get; }
            public string Street { set; get; }
            public int BuildingNumber { set; get; }




            public DeliveryAddress(string city, string Street, int buildingNumber)
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


        #region Shipment struct
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

            public string TrackingCode => trackingCode;

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

            public decimal EstimatedCost
            {
                get
                {
                    return deliveryFee + (weight * 5);
                }
            }
            #endregion

            #region Add constructor overloading to Shipment:
            public Shipment(string trackingCode)
            {
                this.trackingCode = trackingCode;
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
            public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            {
                this.trackingCode = trackingCode;
                this.description = description;
                this.weight = weight;
                this.deliveryFee = deliveryFee;
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
                    $"{Destination.BuildingNumber}\nTracking Code : {trackingCode}\nDescription : {description}\nWeight : {weight}\nDelivery Fee : {deliveryFee}\n" +
                    $"estimated cost : {EstimatedCost}\n\n");
            }
            #endregion
        }
        #endregion

        #region DeliveryCenter struct
        public struct DeliveryCenter
        {

            private Shipment[] shipment ;
            public DeliveryCenter() { this.shipment =new Shipment[10]; }
            public DeliveryCenter(Shipment[] shpment)
            {
                this.shipment = shpment;
            }
            public Shipment this[int index]
            {
                get
                {
                    if (index >= 0 && index < shipment.Length)
                    {
                        return shipment[index];
                    }
                    else { return default; ; }
                }
                set
                {
                    if (index >= 0 && index < shipment.Length)
                    {
                        shipment[index] = value;
                    }
                }
            }

            public Shipment this[string TrackingCode]
            {
                get
                {
                    for (int i = 0; i < shipment.Length; i++)
                    {
                        if (shipment[i].TrackingCode == TrackingCode)
                        {
                            return shipment[i];
                        }

                    }
                    return default;
                }
            }

            public bool AddShipment(Shipment s_shipment)
            {
                if (shipment == null) shipment = new Shipment[10];

                for (int i = 0; i < shipment.Length; i++)
                {
                    if (string.IsNullOrEmpty(shipment[i].TrackingCode))
                    {
                        shipment[i] = s_shipment;
                        return true;
                    }

                }
                return false;
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


            #region *) In Main, build a Console Application

            DeliveryCenter d1 = new DeliveryCenter();

            int i = 0;
            int j = 0;
            while (i < 3)
            {
                Console.WriteLine($"enter shipment {j + 1} Data : ");
                Console.Write("Tracking Code : ");
                string code = Console.ReadLine();
                Console.Write("Descriptino : ");
                string discription = Console.ReadLine();
                Console.Write("Weight : ");
                decimal weight = decimal.Parse(Console.ReadLine());
                Console.Write("Delivery Fee : ");
                decimal fee = decimal.Parse(Console.ReadLine());
                Console.Write("City : ");
                string City = Console.ReadLine();
                Console.Write("Street : ");
                string street = Console.ReadLine();
                Console.Write("Building Number : ");
                int B_N = int.Parse(Console.ReadLine());

                DeliveryAddress d_a1 = new DeliveryAddress(City, street, B_N);
                Shipment shipment = new Shipment(code , discription , weight , fee , d_a1);
                if (d1.AddShipment(shipment))
                {
                    Console.WriteLine("Shipment added successfully.\n");
                }
                else { Console.WriteLine("Delivery center is full.\n"); }

                i++;
                j++;
            }

            Console.WriteLine("================ ALL SHIPMENTS ================");
            for(int k = 0; k < 3; k++)
            {
                d1[k].PrintShipment();
            }
            Console.Write("Enter a Tracking Code : ");
            string c = Console.ReadLine();
            Shipment found = d1[c];
            if (!string.IsNullOrEmpty(found.TrackingCode))
            {
                found.PrintShipment(); 
            }
            Console.WriteLine("================ STRUCT COPY TEST ================");
            DeliveryAddress oAddress = new DeliveryAddress("Cairo", "Tahrir Street", 15);
            DeliveryAddress cAddress = oAddress;

            cAddress.City = "Cairo";
            cAddress.Street = "Makram Ebeid Street";
            cAddress.BuildingNumber = 20;

            Console.WriteLine($"Original Address: {oAddress.GetFullAddress()}");
            Console.WriteLine($"Copied Address  : {cAddress.GetFullAddress()}");
            #endregion
            #endregion
        }
    }
}
