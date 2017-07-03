namespace App2.Models
{
    public class Item : BaseDataObject
	{
		string ingredients = string.Empty;
		public string Ingredients
		{
			get { return ingredients; }
			set { SetProperty(ref ingredients, value); }
		}

		string method = string.Empty;
		public string Method
		{
			get { return method; }
			set { SetProperty(ref method, value); }
		}
        
        int image;
        public int Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        int isVegetarian;
        public int IsVegetarian
        {
            get { return isVegetarian; }
            set { SetProperty(ref isVegetarian, value); }
        }

        int recom;
        public int Recom
        {
            get { return recom; }
            set { SetProperty(ref recom, value); }
        }

        string imagedata = string.Empty;
        public string Imagedata
        {
            get { return imagedata; }
            set { SetProperty(ref imagedata, value); }
        }

        string serves = string.Empty;
        public string Serves
        {
            get { return serves; }
            set { SetProperty(ref serves, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        int length;
        public int Length
        {
            get { return length; }
            set { SetProperty(ref length, value); }
        }

        int preptimemin;
        public int Preptimemin
        {
            get { return preptimemin; }
            set { SetProperty(ref preptimemin, value); }
        }

        int cookinmin;
        public int Cookinmin
        {
            get { return cookinmin; }
            set { SetProperty(ref cookinmin, value); }
        }
        int favourite;
        public int Favourite
        {
            get { return favourite; }
            set { SetProperty(ref favourite, value); }
        }

    }
}
