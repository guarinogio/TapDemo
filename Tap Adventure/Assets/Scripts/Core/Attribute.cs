using UnityEngine;
using System.Collections;
using System;

public class Attribute{

    private ATTRIBUTE_TYPE type;
    private ATTRIBUTE_FORMULA formula;

    private double factor1;
    private double factor2;

    private double factorCost1;
    private double factorCost2;

    private double cost;
    private double initCost;
    private double lastCost;

    private int lvl;
    private int maxLVL;

    private double initValue;
    private double initValue2;

    private double lastValue;
    private double lastValue2;


    public double value { get; private set; }
    public double value2 { get; private set; }

    public bool isMax { get; private set; }

    public Attribute(ATTRIBUTE_TYPE type, float value)
    {
        this.type = type;
        cost = 100;
        lvl = 1;
        this.value = value;
        this.value2 = value;
        this.initValue = value;
        this.initValue2 = value;
        isMax = false;
    }

    public Attribute(ATTRIBUTE_TYPE type, double initValue, double initValue2, double cost, int maxLVL)
    {
        this.type = type;
        lvl = 1;
        this.value = initValue;
        this.value2 = initValue2;
        this.initValue = value;
        this.initValue2 = value2;
        this.cost = cost;
        this.initCost = cost;
        this.lastCost = cost;
        isMax = false;
        this.maxLVL = maxLVL;
    }


    public void SetFormula(ATTRIBUTE_FORMULA formula, double factor1, double factor2, double factorCost1, double factorCost2)
    {
        this.formula = formula;
        this.factor1 = factor1;
        this.factor2 = factor2;
        this.factorCost1 = factorCost1;
        this.factorCost2 = factorCost2;
    }

    public void SetFormula(ATTRIBUTE_FORMULA formula, double factor1, double factorCost1)
    {
        this.formula = formula;
        this.factor1 = factor1;
        this.factor2 = factor1;
        this.factorCost1 = factorCost1;
        this.factorCost2 = factorCost1;
    }

    public bool Buy(int coins)
    {
        if (coins >= cost && !isMax)
        {
            LvlUP();
            return true;
        }
        else
        {
            return false;
        }
    }


    // Falta actualizar otras variables
    private void LvlUP()
    {

        if (!isMax)
        {
            double pivot1 = value;
            double pivot2 = value2;
            double costPivot = cost;
            lvl++;


            switch (formula)
            {
                case ATTRIBUTE_FORMULA.FUNTION1:
                    value = Funtion1(factor1,factor2);
                    value2 = Funtion1(factor1, factor2);
                    break;
                case ATTRIBUTE_FORMULA.FUNTION2:
                    value = Funtion2(factor1, lastValue);
                    value2 = Funtion2(factor1, lastValue2);
                    break;
                case ATTRIBUTE_FORMULA.FUNTION3:

                    value = Funtion3(factor1, initValue);
                    value2 = Funtion3(factor1, initValue2);
                    cost = Funtion3(factorCost1, initCost);

                    break;
                case ATTRIBUTE_FORMULA.FUNTION4:
                    value = Funtion4(factor1, initValue);
                    value2 = Funtion4(factor1, initValue2);
                    break;
                default:
                    break;
            }

            //cost++;
            lastValue = pivot1;
            lastValue2 = pivot2;
            lastCost = costPivot;

            if (lvl >= maxLVL)
            {
                isMax = true;
            }
        }
    }

    public double Funtion3(double m, double c)
    {
        return m * lvl + c;
    }

    public double Funtion1(double factor1, double factor2)
    {
        //GetFibonacciForLevel
        double ret = 0.0d;
        double n = this.lvl;
        double x = this.initValue;
        double y = this.initValue2;
        double a = factor1;
        double b = factor2;
        double sqrtaa4b = System.Math.Sqrt(a * a * 4 * b);
        ret = ((1.0d / sqrtaa4b) * (System.Math.Pow(2, (-n - 1)))) * ((System.Math.Pow((a - sqrtaa4b), n)*((a * x) - (2 * y))) + ((System.Math.Pow((a + sqrtaa4b), n))*((2 * y) - (a * x))) + ((x * sqrtaa4b) * System.Math.Pow((a - sqrtaa4b), n)) + ((x * sqrtaa4b) * System.Math.Pow((a + sqrtaa4b), n)));

        return ret;
    }

    public double Funtion2(double factor, double lastValue)
    {
        return factor * lastValue;
    }

    public double Funtion4(double factor, double initValue)
    {
        return (factor * Mathf.Log(lvl)) + initValue;
    }
}
