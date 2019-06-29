namespace PizzaCalories
{
    public class Dough
    {
        private const double white = 1.5;
        private const double wholegrain = 1.0;
        private const double crispy = 0.9;
        private const double chewy = 1.1;
        private const double homemade = 1.0;

        private string flour;
        private string bakingTechnique;
        private double weight;

        public Dough(string flour, string bakingTechnique, double weight)
        {
            this.Flour = flour;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string Flour
        {
            get { return flour; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new System.Exception("Invalid type of dough.");
                }

                flour = value;
            }
        }
        private string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new System.Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        private double Weight
        {
            get { return weight; }
            set
            {
                if (value <= 0 || value > 200)
                {
                    throw new System.Exception("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }
        public double Calories
        {
            get => CalculateCalories();
        }

        private double CalculateCalories()
        {
            double flourModifier = 0;
            double bakingModifier = 0;

            if (this.Flour.ToLower() == "white")
            {
                flourModifier = white;
            }
            else if (this.Flour.ToLower() == "wholegrain")
            {
                flourModifier = wholegrain;
            }

            if (this.BakingTechnique.ToLower() == "crispy")
            {
                bakingModifier = crispy;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                bakingModifier = chewy;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                bakingModifier = homemade;
            }

            return (this.Weight * 2) * flourModifier * bakingModifier;
        }

    }
}