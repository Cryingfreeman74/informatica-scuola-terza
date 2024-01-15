                       
name "es_1"

.model small

.data
    num1 DB 1Ah  ;variabile di un byte contenente 1A
    num2 DB 0D2h ;variabile di un byte contenente D2
    ris DB ?     ;genero una variabile di un byte vuota
.code
    .startup
        MOV AX, @data   ;prima riga eseguita, @data contiene il valore della posizione in cui risiede il segmento dati (carico i dati in ax)
        MOV DS, AX      ;copio il valore di AX in DS. DS è un registro standard. punta nella posizione in cui si vuole conservare i valori.
        MOV AX, 0000h   ;porto a 0 il valore di AX (azzero i registri)
        MOV BX, 0000h   ;porto a 0 il valore di BX (azzero i registri)
        MOV AL, num1    ;carico num1 in Al
        MOV BL, num2    ;carico num2 in Bl
        ADD AL, BL      ;calcolo la somma
        MOV ris, AL     ;salvo il valore nella variabile ris
        int 20h         ;interrupt
    .exit
end