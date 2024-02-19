;Marco Balducci 3H 05-02-2024
;Controllo parita' di una parola

name "esercizio 8"

.model small

.data

    num dw 23 ;parola di cui viene controllata la parita'
    
.code
.startup
    
    ;inizializzazione registri
    mov bx, 0
    mov ax, 0                    
    
    add bx, num ;al momento dell'inserimento di un valore pari il parity flag assume valore 0, altrimenti 1
    
    
    JNP FINE     ;jump se pf = 0, la parola e' pari
    
    mov ax, 1   ;se dispari allora inserisco 1 in al, altrimenti l'istruzione e' ignorata
    
    FINE:       ;se pari al rimane a 0
    
.exit
END