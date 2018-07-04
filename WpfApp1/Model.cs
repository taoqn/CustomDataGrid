using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WpfApp1
{
    public class FormSuaNhomXetNghiem : INotifyPropertyChanged
    {
        private List<OrderInfo> _ordersDetails;
        public FormSuaNhomXetNghiem()
        {
            OrderInfoRepository order = new OrderInfoRepository();
            OrdersInfos = order.GetOrdersDetails(20);
        }
        public List<OrderInfo> OrdersInfos
        {
            get { return _ordersDetails; }
            set { _ordersDetails = value; RaisePropertyChanged("OrdersInfos"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class OrderInfo : INotifyPropertyChanged
    {
        private int _OrderID;
        private string _CustomerID;
        private System.Nullable<int> _EmployeeID;
        private string _ShipCity;
        private string _ShipCountry;
        private double _Freight;
        private List<OrderDetails> orderDetails;
        private bool _isClosed;
        private DateTime _shippingDate;
        public OrderInfo()
        {

        }
        public List<OrderDetails> OrderDetails
        {
            get
            {
                return this.orderDetails;
            }
            set
            {
                this.orderDetails = value;
                RaisePropertyChanged("OrderDetails");
            }
        }
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this._OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this._CustomerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }
        public DateTime ShippingDate
        {
            get
            {
                return _shippingDate;
            }
            set
            {
                _shippingDate = value;
                RaisePropertyChanged("ShippingDate");
            }
        }
        public System.Nullable<int> EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this._EmployeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }
        public string ShipCity
        {
            get
            {
                return this._ShipCity;
            }
            set
            {
                this._ShipCity = value;
                RaisePropertyChanged("ShipCity");
            }
        }
        public string ShipCountry
        {
            get
            {
                return this._ShipCountry;
            }
            set
            {
                this._ShipCountry = value;
                RaisePropertyChanged("ShipCountry");
            }
        }
        public double Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                this._Freight = value;
                RaisePropertyChanged("Freight");
            }
        }
        public bool IsClosed
        {
            get
            {
                return this._isClosed;
            }

            set
            {
                this._isClosed = value;
                this.RaisePropertyChanged("IsClosed");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
    public class OrderDetails : INotifyPropertyChanged
    {
        private System.Nullable<int> _OrderID;
        public System.Nullable<int> OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this._OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }
        private int _ProductID;
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this._ProductID = value;
                RaisePropertyChanged("ProductID");
            }
        }
        private decimal _UnitPrice;
        public decimal UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this._UnitPrice = value;
                RaisePropertyChanged("UnitPrice");
            }
        }
        private Int16 _Quantity;
        public Int16 Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }
        private double _Discount;
        public double Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
                RaisePropertyChanged("Discount");
            }
        }

        private string _customerID;
        public string CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                RaisePropertyChanged("OrderDate");
            }
        }
        private List<OrderOP> orderOPs;
        public List<OrderOP> OrderOPs
        {
            get
            {
                return this.orderOPs;
            }
            set
            {
                this.orderOPs = value;
                RaisePropertyChanged("OrderOP");
            }
        }
        public OrderDetails(int ord, int prod, decimal unit, Int16 quan, double disc, string cusid, DateTime ordDt, List<OrderOP> or)
        {
            this._Discount = disc;
            this._OrderID = ord;
            this._ProductID = prod;
            this._Quantity = quan;
            this._UnitPrice = unit;
            this._customerID = cusid;
            this._orderDate = ordDt;
            this.orderOPs = or;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class OrderOP : INotifyPropertyChanged
    {
        private System.Nullable<int> _OrderID;
        public System.Nullable<int> OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this._OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }
        private int _ProductID;
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this._ProductID = value;
                RaisePropertyChanged("ProductID");
            }
        }
        private string _customerID;
        public string CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }
        private List<OrderChild> _orderChild;
        public List<OrderChild> OrderChild
        {
            get
            {
                return this._orderChild;
            }
            set
            {
                this._orderChild = value;
                RaisePropertyChanged("OrderChild");
            }
        }
        public OrderOP(int ord, int prod, string cusid, List<OrderChild> _ord)
        {
            this._OrderID = ord;
            this._ProductID = prod;
            this._customerID = cusid;
            this._orderChild = _ord;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class OrderChild : INotifyPropertyChanged
    {
        private System.Nullable<int> _OrderID;
        public System.Nullable<int> OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this._OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }
        private int _ProductID;
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this._ProductID = value;
                RaisePropertyChanged("ProductID");
            }
        }
        private string _customerID;
        public string CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }
        public OrderChild(int ord, int prod, string cusid)
        {
            this._OrderID = ord;
            this._ProductID = prod;
            this._customerID = cusid;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class OrderInfoRepository
    {
        Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();
        private List<DateTime> OrderedDates;
        Random r = new Random();
        List<OrderDetails> ord = new List<OrderDetails>();

        public List<string> Customers { get { return this.CustomerID.ToList(); } }
        public List<string> ShipCountries { get { return this.ShipCountry.ToList(); } }
        public OrderInfoRepository()
        {
        }
        public List<OrderInfo> GetOrdersDetails(int count)
        {
            List<OrderInfo> ordersDetails = new List<OrderInfo>();
            this.OrderedDates = GetDateBetween(2008, 2012, count);
            OrdersAdd(count);
            SetShipCity();
            for (int i = 10000; i < count + 10000; i++)
            {
                ordersDetails.Add(GetOrder(i));
            }
            return ordersDetails;
        }
        private void OrdersAdd(int count)
        {
            List<OrderChild> lischild = new List<OrderChild>();
            OrderChild o1 = new OrderChild(0, 100, "NEU#");
            lischild.Add(o1);
            OrderChild o2 = new OrderChild(1, 200, "LYM#");
            lischild.Add(o2);
            OrderChild o3 = new OrderChild(2, 300, "MONO#");
            lischild.Add(o3);
            OrderChild o4 = new OrderChild(3, 400, "EOS#");
            lischild.Add(o4);

            List<OrderOP> lis = new List<OrderOP>();
            OrderOP op = new OrderOP(0, 100, "WBC", lischild);
            lis.Add(op);
            OrderOP op1 = new OrderOP(1, 200, "RBC", lischild);
            lis.Add(op1);
            OrderOP op2 = new OrderOP(2, 300, "PLT", lischild);
            lis.Add(op2);
            OrderOP op3 = new OrderOP(3, 400, "CKC", lischild);
            lis.Add(op3);

            ord.Add(new OrderDetails(10000, 12, 23, 5, 10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10000, 14, 59, 10, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10000, 18, 23, 5, 10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10000, 34, 59, 10, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10000, 14, 59, 10, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10000, 18, 23, 5, 10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10000, 34, 59, 10, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10001, 23, 45, 76, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10001, 45, 67, 23, 5, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10001, 45, 42, 16, 3, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10001, 23, 95, 15, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10002, 7, 70, 6, 4, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10002, 2, 30, 5, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10003, 23, 73, 9, 3, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10003, 8, 11, 8, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10003, 1, 150, 1, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10009, 4, 35, 4, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10009, 2, 31, 7, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10010, 7, 23, 3, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10010, 5, 65, 4, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10010, 3, 15, 5, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10010, 2, 31, 1, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10011, 6, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10011, 3, 45, 4, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10011, 2, 41, 7, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10013, 19, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10013, 20, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10021, 54, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10021, 63, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10021, 27, 99, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10022, 59, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10022, 60, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10022, 47, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10032, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10032, 6, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10034, 17, 99, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10034, 19, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10034, 20, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10042, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10042, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10045, 6, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10045, 17, 99, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10045, 19, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10045, 20, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10056, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10056, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10056, 6, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10067, 17, 99, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10067, 19, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
            ord.Add(new OrderDetails(10067, 20, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)], lis));
        }

        private OrderInfo GetOrder(int i)
        {
            var shipcountry = ShipCountry[r.Next(5)];
            var shipcitycoll = ShipCity[shipcountry];
            return new OrderInfo()
            {
                OrderID = i,
                CustomerID = CustomerID[r.Next(15)],
                EmployeeID = r.Next(1, 10),
                Freight = Math.Round(r.Next(1000) + r.NextDouble(), 2),
                ShipCountry = shipcountry,
                ShippingDate = this.OrderedDates[i - 10000],
                IsClosed = i % 2 == 0 ? true : false,
                ShipCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)],
                OrderDetails = getorder(i)
            };
        }

        public List<OrderDetails> getorder(int i)
        {
            List<OrderDetails> order = new List<OrderDetails>();
            foreach (var or in ord)
                if (or.OrderID == i)
                    order.Add(or);
            return order;
        }

        string[] ShipCountry = new string[] { "Argentina", "Austria", "Belgium", "Brazil", "Canada", "Denmark", "Finland", "France", "Germany", "Ireland", "Italy", "Mexico", "Norway", "Poland", "Portugal", "Spain", "Sweden", "Switzerland", "UK", "USA", "Venezuela" };

        private void SetShipCity()
        {
            string[] argentina = new string[] { "Hồ Chí Minh" };

            string[] austria = new string[] { "Graz", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinas", "Resende", "Rio de Janeiro", "São Paulo" };

            string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = new string[] { "Århus", "København" };

            string[] finland = new string[] { "Helsinki", "Oulu" };

            string[] france = new string[] { "Lille", "Lyon", "Marseille", "Nantes", "Paris", "Reims", "Strasbourg", "Toulouse", "Versailles" };

            string[] germany = new string[] { "Aachen", "Berlin", "Brandenburg", "Cunewalde", "Frankfurt a.M.", "Köln", "Leipzig", "Mannheim", "München", "Münster", "Stuttgart" };

            string[] ireland = new string[] { "Cork" };

            string[] italy = new string[] { "Bergamo", "Reggio Emilia", "Torino" };

            string[] mexico = new string[] { "México D.F." };

            string[] norway = new string[] { "Stavern" };

            string[] poland = new string[] { "Warszawa" };

            string[] portugal = new string[] { "Lisboa" };

            string[] spain = new string[] { "Barcelona", "Madrid", "Sevilla" };

            string[] sweden = new string[] { "Bräcke", "Luleå" };

            string[] switzerland = new string[] { "Bern", "Genève" };

            string[] uk = new string[] { "Colchester", "Hedge End", "London" };

            string[] usa = new string[] { "Albuquerque", "Anchorage", "Boise", "Butte", "Elgin", "Eugene", "Kirkland", "Lander", "Portland", "San Francisco", "Seattle", "Walla Walla" };

            string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

            ShipCity.Add("Argentina", argentina);
            ShipCity.Add("Austria", austria);
            ShipCity.Add("Belgium", belgium);
            ShipCity.Add("Brazil", brazil);
            ShipCity.Add("Canada", canada);
            ShipCity.Add("Denmark", denmark);
            ShipCity.Add("Finland", finland);
            ShipCity.Add("France", france);
            ShipCity.Add("Germany", germany);
            ShipCity.Add("Ireland", ireland);
            ShipCity.Add("Italy", italy);
            ShipCity.Add("Mexico", mexico);
            ShipCity.Add("Norway", norway);
            ShipCity.Add("Poland", poland);
            ShipCity.Add("Portugal", portugal);
            ShipCity.Add("Spain", spain);
            ShipCity.Add("Sweden", sweden);
            ShipCity.Add("Switzerland", switzerland);
            ShipCity.Add("UK", uk);
            ShipCity.Add("USA", usa);
            ShipCity.Add("Venezuela", venezuela);

        }
        string[] CustomerID = new string[] { "ALFKI", "FRANS", "MEREP", "FOLKO", "SIMOB", "WARTH", "VAFFE", "FURIB", "SEVES", "LINOD", "RISCU", "PICCO", "BLONP", "WELLI", "FOLIG" };
        private List<DateTime> GetDateBetween(int startYear, int EndYear, int Count)
        {
            List<DateTime> date = new List<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < Count; i++)
            {
                int year = y.Next(startYear, EndYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);
                date.Add(new DateTime(year, month, day));
            }
            return date;
        }
    }
}
