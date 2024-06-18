getBreakerName:
      mov r4, #getBreakerNameMss
      mov r5, #breakerName
      str r4, .WriteString
      str r5, .ReadString
getMakerName:
      mov r4, #getMakerNameMss
      mov r6, #makerName
      str r4, .WriteString
      str r6, .ReadString
getMaxQueries:
      mov r4, #getMaxQueriesMss
      str r4, .WriteString
      ldr r7, .InputNum
      strb r7, maxGuessAllowed
printInfo:
      bl newline
printBreakerName:
      mov r4, #breakerNameNoti
      str r4, .WriteString
      str r5, .WriteString 
      bl newline
printMakerName:
      mov r4, #makerNameNoti
      str r4, .WriteString
      str r6, .WriteString 
      bl newline
printMaxGuessAllowed:
      mov r4, #maxQueriesNoti
      str r4, .WriteString 
      str r7, .WriteUnsignedNum
      bl newline
      bl newline
getSecretCode: 
      push {r0, r1, r2}
      mov r0, #secretcode
      mov r1, #getCodeMss
      mov r2, #makerName
      bl getcode
      pop {r0, r1, r2}
; breakerTurn      
      bl newline
      ldrb r7, maxGuessAllowed
      add r7, r7, #1
      mov r9, #1
breakerGuess:
      mov r6, #breakerName
      str r6, .WriteString 
      mov r4, #guessMss
      str r4, .WriteString
      str r9, .WriteUnsignedNum
      bl newline
getQueryCode:
      push {r0, r1, r2}
      mov r0, #querycode
      mov r1, #getCodeMss
      mov r2, #breakerName
      bl getcode
      pop {r0, r1, r2}
compareWithSecret:
      push {r0, r1}
      mov r0, #secretcode
      mov r1, #querycode
      bl comparecodes
      mov r11, r0
      mov r12, r1
      pop {r0, r1}
printResult:
      mov r4, #case1noti
      str r4, .WriteString
      str r11, .WriteUnsignedNum
      mov r4, #case2noti
      str r4, .WriteString
      str r12, .WriteUnsignedNum
guessCheck:
      cmp r11, #4
      bne enterAgain
      mov r4, #breakerName
      str r4, .WriteString
      mov r4, #winMss
      str r4, .WriteString
      b exit
enterAgain:
      add r9, r9, #1
      cmp r9, r7
      bl newline
      blt breakerGuess
; outOfTurn
      mov r4, #breakerName
      str r4, .WriteString
      mov r4, #loseMss
      str r4, .WriteString
exit:
      mov r4, #endNoti
      str r4, .WriteString
      halt
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
newline: ; put an \n next to the current console display
      push {r4}
      mov r4, #newlinechar
      str r4, .WriteString
      pop {r4}
      ret
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
getcode:
      push {r4, r5, r6, r7, r8}
      mov r7, r2
      mov r4, r1
      mov r5, r0
      b input
reEnter:
      mov r8, #reEnterMss
      str r8, .WriteString
input:
      mov r6, #0
      str r7, .WriteString  ; subject of the mss
      mov r4, r1
      str r4, .WriteString  ; request of the mss
      str r5, .ReadString   ; get the code
validate:
      ldrb r4, [r5 + r6]
      cmp r4, #0x72       ; red check
      beq continue
      cmp r4, #0x67       ; green check
      beq continue
      cmp r4, #0x62       ; blue check 
      beq continue 
      cmp r4, #0x79       ; yellow check
      beq continue 
      cmp r4, #0x70       ; purple check
      beq continue
      cmp r4, #0x63       ; cyan check
      beq continue
      b reEnter
continue:
      add r6, r6, #1
      cmp r6, #4
      blt validate        ; continue with the next char
      ldrb r4, [r5 + r6]
      cmp r4, #0          ; check if there exists a 5th char in the code entered
      bne reEnter
      pop {r4, r5, r6, r7, r8}
      ret
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
comparecodes:
; r0 is secret code add & case 1 counter (right position)
; r1 is query code add & case 2 counter (right color)
; r4 is address of secret code
; r5 is address of query code
; r6 is secret code index
; r7 is query code index
; r8 is secret char
; r9 is query char
      push {r4, r5, r6, r7, r8, r9}
      mov r4, r0
      mov r5, r1
      mov r0, #0
      mov r1, #0
      mov r6, #0
      mov r7, #0
compare:
      ldrb r8, [r4 + r6]
      ldrb r9, [r5 + r7]
      cmp r8, r9
      bne next
      cmp r6, r7
      beq posMatch
colorMatch:
      add r1, r1, #1
      b next
posMatch: 
      add r0, r0, #1
next:
      add r6, r6, #1
      cmp r6, #4
      blt compare
      mov r6, #0
      add r7, r7, #1
      cmp r7, #4
      blt compare
      pop {r4, r5, r6, r7, r8, r9}
      ret

newlinechar: .ASCIZ "\n"
getMakerNameMss: .ASCIZ "Enter code maker name: \n"
getBreakerNameMss: .ASCIZ "Enter code breaker name: \n"
getMaxQueriesMss: .ASCIZ "Enter maximum number of queries allowed: \n"
breakerNameNoti: .ASCIZ "Codebreaker is "
makerNameNoti: .ASCIZ "Codemaker is "
maxQueriesNoti: .ASCIZ "Maximum number of guesses: "
makerName: .BLOCK 64
breakerName: .BLOCK 64
maxGuessAllowed: .BYTE 0
getCodeMss: .ASCIZ ", please enter a 4-character secret code\n"
reEnterMss: .ASCIZ "\nInvalid code! Enter again \n"
guessMss: .ASCIZ ", this is guess number: "
secretcode: .BYTE 0
      0
      0
      0
      0
querycode: .BYTE 0
      0
      0
      0
      0
case1noti: .ASCIZ "Position matches: "
case2noti: .ASCIZ ", Color matches: "
winMss: .ASCIZ ", you WIN!\n"
loseMss: .ASCIZ ", you LOSE!\n"
endNoti: .ASCIZ "Game Over!\n"
