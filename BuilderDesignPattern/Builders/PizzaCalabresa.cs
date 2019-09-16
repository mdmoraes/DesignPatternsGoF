﻿using System;

namespace BuilderDesignPattern.Builders
{
    using Base;
    using Domain;
    using Domain.ValueObject;
    using Processors;

    public sealed class PizzaCalabresa : PizzaBuilderBase, IPizzaBuilder
    {
        public PizzaCalabresa(ICalculaValor calculaValor) 
            : base(calculaValor)
        {
            this.Pizza.PizzaType = PizzaType.Salgada;
        }

        public void PrepraraBorda(Borda borda)
        {
            if((this.Pizza.PizzaType == PizzaType.Doce) && (this.Pizza.Borda?.BordaType != BordaType.Chocolate))
                throw new Exception("Não é possível colocar borda de chocolae em uma pizza de calabresa");
        }

        public void PreparaMass(PizzaSize pizzaSize, Borda borda = null)
        {
            this.Pizza.Borda = borda;
            this.Pizza.PizzaSize = pizzaSize;
        }
        public void PreparaMassSemBorda(PizzaSize pizzaSize)
        {
            this.Pizza.PizzaSize = pizzaSize;
        }

        public void InsereIngradientes()
        {
            this.Pizza.Sabor = "Calabresa";
            this.Pizza.IngredientesType =
                IngredientesType.Calabresa |
                IngredientesType.Azeitona |
                IngredientesType.Cebola |
                IngredientesType.Cheddar |
                IngredientesType.Salame;
        }

        public void TempoForno()
        {
            this.Pizza.TempoFornoMin = 20;
        }
    }
}
