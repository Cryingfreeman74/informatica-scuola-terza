;Marco Balducci 3H 05/02/2024
;Gestione array tramite somma al puntatore

name "esercizio 6"

.model small
.data
    vett dw 5,7,3,4,3
    risultato dw ?

.code
.startup
    mov ax, 0
    add ax, vett     ;aggiungo ad ax quello che si trova alla pos vett
    add ax, vett+2   ;aggiungo ad ax quello che si trova alla pos vett+2
    add ax, vett+4   ;aggiungo ad ax quello che si trova alla pos vett+4
    add ax, vett+6   ;aggiungo ad ax quello che si trova alla pos vett+6
    add ax, vett+8   ;aggiungo ad ax quello che si trova alla pos vett+8
    
    mov risultato, ax
    int 20h
.exit
END