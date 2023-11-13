#!/bin/bash
#Marco Balducci 3H

echo "Premi qualsiasi tasto per lanciare il dado"
read tasto

valoreUscito=${RANDOM:0:1} #ottengo un numero casuale da 0 a 9

echo -e "È uscito il valore $valoreUscito"

if [ $valoreUscito -gt 6 ]; #evito di controllare se esci un valore > di 6
    then echo "Penso che starai a sedere..."
else 
    if [ $valoreUscito -eq 1 ];
        then echo "Sei stato assegnato alla squadra Rossa"
    else
        if [ $valoreUscito -eq 2 ];
            then echo "Sei stato assegnato alla squadra Verde"
        else
            if [ $valoreUscito -eq 3 ];
                then echo "Sei stato assegnato alla squadra Gialla"
            else
                if [ $valoreUscito -eq 4 ];
                    then echo "Sei stato assegnato alla squadra Blu"
                else
                    if [ $valoreUscito -eq 5 ];
                        then echo "Sei stato assegnato alla squadra Rosa"
                    else
                        echo "Sei stato assegnato alla squadra Nera"
                    fi
                fi
            fi
        fi
    fi
fi