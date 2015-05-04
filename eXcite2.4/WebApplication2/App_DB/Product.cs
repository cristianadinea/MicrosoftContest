namespace WebApplication2.App_DB
{
    partial class ProductDataContext
    {

    }

    public partial class Ingredient
    {
        double? _Cantitate;
        public System.Nullable<double> Cantitate
        {
            
            get
            {
                return this._Cantitate;
            }
            set
            {
                if ((this._Cantitate != value))
                {
                    this.OnUnitPriceChanging(value);
                    this.SendPropertyChanging();
                    this._Cantitate = value;
                    this.SendPropertyChanged("Cantitate");
                    this.OnUnitPriceChanged();
                }
            }
        }


    }
}


