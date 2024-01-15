name "esercizio 1" ;salvataggio di un valore decimale

.model small

.data
    variabile dw ? ;variabile chiamata variabile di dimensione 1 word
.code
    .startup
        MOV variabile, 3    ;copio il valore di 3 nella variabile variabile
        MOV AX, variabile   ;copio in ax il valore di variabile
        int 20h             ;interrupt e restituzione controllo
    .exit
end