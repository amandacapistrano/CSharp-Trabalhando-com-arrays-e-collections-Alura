// See https://aka.ms/new-console-template for more information

Console.WriteLine("Calculo de média");

 

double[] amostras = {10.5, 5.5, 4.7};

Console.WriteLine(CalculaMedia(amostras));

 

double CalculaMedia(double[] amostras ){

    double media = 0;

    double soma = 0;

    for(int i = 0; i < amostras.Length; i++)

    {

        soma += amostras[i];

    }

    media = soma / amostras.Length;

   return media;

 

}

 