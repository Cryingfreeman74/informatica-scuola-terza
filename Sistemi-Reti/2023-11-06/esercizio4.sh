#!/bin/bash

echo "Puoi scrivermi il tuo nome?"
read nome
echo "Benissimo, $nome! Vieni pure volontario." #l'operatore dollaro prende il valore della variabile nome
echo "Mi dici quante volte sei stato interrogato?"
read numero
    
#casting: inserire una variabile di un tipo in una di un'altro. casting di un numero: stringa -> intero

if [[ $numero =~ ^[0-5]+$ ]]; then # =~ controlla che il valore di nome sia compreso nell'intervallo [0-5], ^ indica l'inizio della stringa, + che si possono inserire più cifre e $ indica il termine della stringa
    numero_volte=$((numero + 1)) #casting di un numero, ricordarsi di mettere numero=$((stringa)) senza spazi
    echo "quindi questa è la volta numero: $numero_volte"
else
    echo "Penso che ti sia confuso, non è possibile che ti abbia interrogato così spesso"
fi


