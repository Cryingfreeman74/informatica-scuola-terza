#!/bin/bash
#Marco Balducci 3H

echo "Inserisci l'anno"
read anno

if [ $anno -ge 0 ];
    then if (($anno % 4 == 0));
            then if (($anno % 100 == 0 && $anno % 400 != 0));
                    then echo -e "Non è bisestile"
                 else
                    echo -e "L'anno è bisestile"
                 fi
         else
            echo -e "Non è bisestile" 
         fi
else 
    echo "ERROR"
fi