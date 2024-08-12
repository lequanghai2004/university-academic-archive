# =======================================================================
#
# Copyright 2019, Luu Quang Hung
# luuquanghung@gmail.com, https://github.com/luuqh
# All rights reserved.
#
# Redistribution and use in source and binary forms, with or without
# modification, are permitted provided that the following conditions are
# met:
#
#     * Redistributions of source code must retain the above copyright
# notice, this list of conditions and the following disclaimer.
#     * Redistributions in binary form must reproduce the above
# copyright notice, this list of conditions and the following disclaimer
# in the documentation and/or other materials provided with the
# distribution.
#
# THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
# "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
# LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
# A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
# OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
# SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
# LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
# DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
# THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
# (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
# OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#
# =======================================================================
#
#
# Please cite this paper in your referennce if you use this script for your
# assignment or work.
#
# Quang-Hung Luu, Man F. Lau, Sebastian P.H. Ng and Tsong Yueh Chen (2021) 
# Testing multiple linear regression systems with metamorphic testing, 
# Journal of Systems and Software, 182(111062), doi:10.1016/j.jss.2021.111062
#
# Notes:
# The script is developed to automatically generate mutants for C/C++ program only.
# Please refactor the mutation operators for your own programming language.
# 
#
# =======================================================================
# 
# library
import sys
import pickle


# mutation dataset
mutation_keys = {
    "logic_compare":
        ["!=","<",">","<=",">=","=="],
    "logic_and":
        ["|","^","&&","&","||","&&!"],
    "logic_not":
        ["~","!"],
    "logic_bool":
        ["true","false"],
    "logic_return":
        ["?","&&false?","||true?"],
    "math_operator":
        ["+","-","*","/","%"],
    "math_increment":
        ["++","--","+=2","-=2"],
    "math_value":
        ["=0","=1","=2"],
    "math_numeric":
        ["+1","-1","+2","-2"],
    "condition_if":
        ["if(","if(!","if(true||","if(false&&"],
    "condition_while":
        ["while(","while(!","while(~","while(false&&"],
    "condition_loop":
        ["break;","continue;","{;}"],
    "condition_index":
        ["i=","j=","k="],
    "function_return":
        ["return ","return 0;//","return 1;//","return NULL;//","return -1;//","return 2*","return -1*"],
    "matrix_index":
        ["[","[-1+","[1+","[0*"],
    "array_index":
        [");","*0);","*(-1));","*2);"],
    "array_swap1":
        ["[i]","[j]","[k]","[0]","[1]"],
    "array_swap2":
        ["[i][j]","[j][i]","[i][k]","[k][i]","[j][k]","[k][j]"],
    "array_element":
        [",",",!",",0*",",-1*",",2*"],
    "data_double":
        ["Doub","MathDoub","MathDoub_I","VecDoub_I","VecDoub"],
    "data_integer":
        ["Doub","Int"]
}


# create a nested dictionary of lists from dictionary of words
def dict_nested (dict_set):
    nd = dict()
    for key in list(dict_set.keys()):
        dict_sub = dict()
        ds = dict_set[key]
        for key_main in ds:
            set_remain = [] # list to store non-duplicated words
            for key_other in ds:
                if (key_other!=key_main):
                    set_remain.append(key_other)
            dict_sub[key_main] = set_remain
        nd[key] = dict_sub
    return nd


# print nested dictionary of lists
def print_nested (keydict):
    for keyset in keydict:
        print("\n*****",keyset,"\n")
        keys = keydict[keyset]
        for key in keys:
            print(key)
            print(keys[key])


# write mutations to file
def write_mutations_to_file (mutant_file_name, source, mutated_line, textchange) :
    output_file = open(mutant_file_name, "w")
    for i in range(0,len(source)):
        if i == mutated_line:
            output_file.write("# ORIGINAL CODE:\n #"+source[i]+"\n# MODIFIED TO:\n")
            output_file.write(textchange+"\n")
        else:
            output_file.write(source[i]+"\n")
    output_file.close()


# remove blank spaces next to operators, retain blank space before actual code
def compact_operator (source, search_depth=10):
    operator_set = ['(',')','[',']','.',',',';','+','-','*','/','=','>','<']
    blank_set = [' ']
    blank_word = ''
    for _ in range(search_depth): # number of blanks (1,2,4,6..)
        blank_word += '  '
        blank_set.append(blank_word)
    string_main = source
    for i in range(len(string_main)): # retain prefix blank
        if string_main[i]!=' ':
            break;
    string_header = string_main[:i]
    string_main = string_main[i:]
    for operator in operator_set: # replace blanks in prefix and suffix of operator
        for blank in reversed(blank_set):
            string_main = string_main.replace(operator+blank,operator)
            string_main = string_main.replace(blank+operator,operator)
    return string_header+string_main


# replace keyword(s) in source by keychange
def replace_string (source, keyword, keychange):
    index_end = 0
    input_string = compact_operator(source)
    output_string = []
    while index_end < len(input_string):
        index_start = input_string.find(keyword, index_end)
        if index_start == -1:
            break
        index_end = index_start + len(keyword)
        mutated_text = input_string[:index_start] + keychange + input_string[index_end:]
        output_string.append(mutated_text)
    return output_string


# save and load object (e.g. dictionary) to file
def save_object (object, filename ):
    with open(filename + '.pkl', 'wb+') as f:
        pickle.dump (object, f, pickle.HIGHEST_PROTOCOL)
def load_object (filename ):
    with open(filename + '.pkl', 'rb') as f:
        return pickle.load(f)


# main program
def main (input_file, output_folder, start_line=0, end_line=-1):
    print("MUTATION FOR C++ PROGRAM\n------------------------")
    mutation_count = 0
    mutation_max = 10000
    stop = False
    keydict = dict_nested (mutation_keys)
    keynote = dict()
    #print_nested (keydict)

    
    # open source file
    source = open (input_file).read().split('\n')
    keynote[0] = [0, '', 0, '', '', '']
    print("NUMBER OF CODE LINES: ",len(source))
    for line in range(0,len(source)):
        if (line >= start_line) and ((line<=end_line) or (end_line<0)):
            if not (source[line].strip().startswith("/*") and source[line].strip().startswith("#include")
                    and source[line].strip().startswith("//") and source[line].strip()):

                
                # find keys in source code
                for keyset in keydict:
                    keys = keydict[keyset]
                    for keyword in keys:
                        no_substring = source[line].count(keyword)
                        if no_substring > 0:
                            for keychange in keys[keyword]:
                      
                      
                                # search and replace original key by mutated key
                                for textchange in replace_string (source[line], keyword, keychange):
                                    mutation_count +=1
                                    print(mutation_count, keyset, line, keyword, keychange, textchange)
                                    keynote[mutation_count] = [mutation_count, keyset, line, keyword, keychange, textchange]
                                    if mutation_count>mutation_max:
                                        stop = True
                                    if stop == False:
                                        output_file = output_folder + str(mutation_count).zfill(8) + '.c'
                                        write_mutations_to_file (output_file, source, line, textchange)
    # print(keynote)
    save_object(keynote,output_folder+'/keynote')


# get parameters for running
if __name__ == "__main__":
    if len(sys.argv)==2:
        main(sys.argv[1],"./",0,-1)
    if len(sys.argv)==3:
        main(sys.argv[1],sys.argv[2])
    if len(sys.argv)==5:
        main(sys.argv[1],sys.argv[2],int(sys.argv[3]),int(sys.argv[4]))
    else:
        print("Usage: python gen_mutatation.py <file-to-mutate.c> [folder-to-store-mutated-files] [start-line] [end-line]")
        print("Example: python gen_mutation.py ../cpp/mlr.c mutations/svd/ 10 440")



