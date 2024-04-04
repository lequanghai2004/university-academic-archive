import re

# special/meta character
# '.' --> any character (wildcard) 
# '^' --> start of line (anchor)                ^na --> name
# '$' --> end of line (anchor)                  me$ --> name
# []  --> character classes 
# not[] == [^]

# '*' --> repeat as many times including 0
# '+' --> 1 or more
# '?' --> 0 or 1
# {n} --> n times

# escape character: \.  \?  \+  \*  \^
# \w == [a-zA-Z0-9_]
# \d == [0-9]
# \s == space, tab, newline
# \b == word boundaries \b.....\b act as ^$ but for words


print(re.search(r"aza", "plaza")) # return span(start, end) or None
print(re.search(r"^xe", "xEnon", re.IGNORECASE)) # xE
print(re.search(r"p.ng", "PeNguin", re.IGNORECASE)) # PeNg

print(re.search(r"[Pp]ython", "Python")) # P or p
print(re.search(r"[a-z]way", "on the highway")) # hway
print(re.search(r"[a-zA-Z0-9]way", "on the way")) # None
print(re.search(r"[^a-zA-Z0-9 ]", "match the dot at the end."))

print(re.search(r"cat|dog", "I like cat"))
print(re.search(r"cat|dog", "I like dog"))

print(re.search(r"py.*on", "python")) # python
print(re.search(r"py.*on", "python programming")) # python programmin --> greedy 
print(re.search(r"py[a-z]*n", "pyn")) # 0 time of repetition

print(re.search(r"p?each", "peach")) # peach
print(re.search(r"p?each", "breach")) # each
print(re.search(r"[\w]*", "This_is a_pen")) # This_is
print(re.findall(r"cat|dog", "cat and cat and dog")) # return a list

print(re.findall(r"\b[a-zA-Z]{5}\b", "a scary ghost appears"))
