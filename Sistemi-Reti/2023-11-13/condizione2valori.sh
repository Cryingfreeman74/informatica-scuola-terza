#!/bin/bash
#Marco Balducci 3H

echo "Inserisci il primo numero"
read numero1
echo "Inserisci il secondo numero"
read numero2

if (($numero1 == $numero2));
    then echo "I due numeri sono uguali."
else
    if [ $numero1 -gt $numero2 ];
        then echo "$numero1 è più grande di $numero2"
    else
        echo "$numero2 è più grande di $numero1"
    fi
fi