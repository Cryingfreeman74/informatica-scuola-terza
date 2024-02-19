;Marco Balducci 3H 05-02-2024
;Gestione array utilizzando ciclo tramite salto condizionato jnz

name "esercizio 7"

DIM EQU 5             ;utilizzo una costante che indica la lunghezza dell'array

.model small

.data
    vett dw 5,7,3,4,3
    risultato dw ?

.code
.startup
    
    ;inizializzazione registri
    mov ax, 0
    add bx, DIM
    mov di, 0
    
    SOMMA:            ;creazione etichetta che punta ad appena prima della somma
    
    add ax, vett[di]  ;sommo ad ax quello che si trova alla posizione vett + di
    add di, 2         ;aumento di per puntare alla posizione successiva nel prossimo ciclo
    dec bx            ;decremento bx
    cmp bx, 0         ;se bx != 0 allora ci sono altri elementi ed il ciclo continua
    jnz SOMMA         ;se il compare ritorna falso allora salto
    
    ;scrittura risultato in variabile
    mov risultato, ax                
    
    int 20h
    
.exit
END