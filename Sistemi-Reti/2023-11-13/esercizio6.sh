#!/bin/bash
#Marco Balducci 3H

#esercizio 6: traduzione di flowchart in codice bash

echo "Digita un numero: "
read numero

if [ $numero -lt 0 ];
    then echo "numero è negativo"
else
    if [ $numero -gt 0 ];
        then echo "Numero è positivo"
    else
        echo "Numero è nullo"
    fi
fi