#!/bin/bash
#Marco Balducci 3H

valore=15              #no spazi!
if [ $valore -eq 10 ]; #spazi prima e dopo la condizione, punto e virgola dopo l'if.
    then echo "il valore è uguale a 10"
else
    echo "..."
fi

#appunti pag. 59
#-eq -> ==
#-ne -> !=
#-gt -> >
#-ge -> >=
#-lt -> <
#-le -> <=

if (($valore == 10)); #con le graffe si usano gli operatori logici della bash, con doppia parentesi tonda si possono usare quelli canonici
    then echo "il valore è uguale a 10"
else
    echo "..."
fi