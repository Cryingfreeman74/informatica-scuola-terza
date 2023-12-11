#!/bin/bash
#sort [nome_file]                           senza parametri mette in ordine crescente le righe ma non sovrascrive il file d'origine
#sort -r                                    mette in ordine decrescente
#sort [nome_file] -o [nome_file_risultato]  salva il risultato nel file risultato, sta per out, se il file esiste già lo sovrascrive
#sort -k2 -n [nome_file]                    se voglio utilzzare come campo di ordinamento uno diverso dalla prima parola uso -k[campo]