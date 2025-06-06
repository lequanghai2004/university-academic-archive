# tester_demo.rb
require 'minitest/autorun'
require_relative 'student'

class StudentTest < Minitest::Test
  def test_student_id_is_integer
    assert_kind_of Integer, get_student_id(2)
  end

  # insert a test here for the finding the correct student for id 300
  def test_find_student_by_id
    assert_equal 'Jill', get_student_name_for_id(300)
  end

  # insert a test here for returning "Not Found" for student with id 800
  def test_if_student_found_in_list
    assert_equal 'Not Found', get_student_name_for_id(800)
  end

  # insert a test here for finding the correct student name for array position 0
  def test_find_student_by_index
    assert_equal 'Fred', get_student_name(0)
  end
end
