import unittest

def validate_user(username, min_len):
  assert type(username) == str, "username must be a string"
  if min_len < 1:
    raise ValueError("min_len must be at least 1")
  if len(username) < min_len:
    return False
  if not username.isalnum():
    return False
  return True