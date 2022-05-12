using System.Text;

namespace FluentApi.Entity{

public class GeneratePlanRequest {
    private string country;
    private string computationType;

    public string getCountry(){return this.country;}

    public void setCountry(string country){ this.country = country;}

    public string getComputationType(){return this.computationType;}

    public void setComputationType(string computationType){ this.computationType = computationType;}


    public static Builder builder(){ return new Builder(); }
    public class Builder{
        protected string computationType;

        public  Builder withComputationType(string computationType)
        {
            this.computationType = computationType;
            return this;
        }

        protected string country;

        public Builder withCountry(string country)
        {
            this.country = country;
            return this;
        }

        public void populate(GeneratePlanRequest instance){
            instance.setComputationType(this.computationType);
            instance.setCountry(this.country);
        }

        public GeneratePlanRequest build(){
            GeneratePlanRequest instance = new GeneratePlanRequest();
            populate(instance);
            return instance;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("country is " + country);
        sb.Append(" computation is " + computationType);
        return(sb.ToString());
    }
}


}
