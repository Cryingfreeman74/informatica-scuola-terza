#!/bin/bash
#Marco Balducci 3H

read -p "Premi 1 per tirare delle monete oppure premi 2 per tirare dei dadi: " scelta

case $scelta in
"1")
./dadi.sh
;;
"2")
./moneta.sh
;;
*)
echo "Non valido"
;;
esac