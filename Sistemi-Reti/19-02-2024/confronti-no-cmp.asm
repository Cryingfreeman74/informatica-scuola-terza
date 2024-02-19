;Marco Balducci 3H 19-02-2024
;Confronti senza cmp

name "confronti senza cmp"
.model small

.data
   A DW 5
   B DW 8
   
.code
.startup
   
   mov dl, 61 ;inizializzo dl con l'uguale =
   mov ax, A
   sub ax, B ;utilizzo la possibilita' di underflow per capire se il primo numero e' minore del secondo
   
   JZ UGUALE
   JS MINORE
   
   MAGGIORE: ;se non entra in nessuno dei jump e' maggiore
   add bl, 2
   add dl, 2
   
   MINORE:
   sub bl, 1
   sub dl, 1
   
   UGUALE:
   ; bl e' gia' zero, non faccio nulla
   
   mov ah, 2
   int 21h
   
   
.exit
END