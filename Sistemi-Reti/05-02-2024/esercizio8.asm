;Marco Balducci 3H 05-02-2024
;Calcolo somma e mdeia degli elementi di un array tramite salto condizionato

name "esercizio 8"

DIM EQU 10                      ;dimensione array

.model small

.data

    Media db ?
    vett dw 1,2,3,4,5,6,7,8,9,10
    Ris dw ?
    rest db ?
    
.code
.startup
    
    ;inizializzazione registri
    mov ax, 0
    add bx, DIM
    mov di, 0
    
    SOMMA:           ;label per il salto prima della somma
    
    add ax, vett[di] ;somma del valore in pos vett+di
    add di, 2        ;incremento del valore in di per accedere alla pos successiva al prossimo ciclo
    dec bx           ;decremento del valore in bx
    cmp bx, 0        ;condizione del ciclo
    jnz SOMMA        ;salto se bx != 0, quindi se nell'array ci sono altri elementi da sommare
    
    mov Ris, ax      ;scrittura risultato in variabile
    
    ;calcolo media
    mov bl, DIM      
    div bl
    
    ;scrittura risultati in variabili
    mov Media, al
    mov rest, ah
    
.exit
END