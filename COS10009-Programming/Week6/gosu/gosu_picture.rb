require 'gosu'
require 'rubygems'
require_relative 'circle.rb'
require_relative 'alternate/bezier_curve.rb'

#use 'debugger' to create a breakpoint

module ZOrder
  BACKGROUND, MIDDLE, TOP = *0..2
end

class GameWindow < Gosu::Window
  def initialize
    super(500, 500, false)
    self.caption = "Le Quang Hai's gosu picture"
    @font = Gosu::Font.new(20)
    
  end

  def draw_cloud(top_left_x, top_left_y)
  Gosu::Image.new(Circle.new(50)).draw(top_left_x + 50, top_left_y, 
    ZOrder::MIDDLE, 1.0, 0.5, Gosu::Color::GRAY)
  Gosu::Image.new(Circle.new(50)).draw(top_left_x, top_left_y + 10, 
    ZOrder::MIDDLE, 1.0, 0.6, Gosu::Color::GRAY)
  Gosu::Image.new(Circle.new(50)).draw(top_left_x + 100, top_left_y + 20, 
    ZOrder::MIDDLE, 1.0, 0.6, Gosu::Color::GRAY)
  Gosu::Image.new(Circle.new(50)).draw(top_left_x + 30, top_left_y + 30, 
    ZOrder::MIDDLE, 1.0, 0.6, Gosu::Color::GRAY)
  end

  def draw_house(top_left_x, top_left_y, width, length)
    # Gosu::Image.new(Circle.new(roof_radius)).draw(top_left_x, top_left_y, ZOrder::TOP, 1.0, 1.0, Gosu::Color::GREEN)
    draw_rect(top_left_x, top_left_y, 
      width, length, Gosu::Color::WHITE)
    draw_rect(top_left_x + 1, top_left_y + 1, 
      width - 2, length - 2, Gosu::Color::BLACK)

    y = top_left_y
    while(y < 350)
      x = top_left_x
      while(x + 49 < top_left_x + width)
        window_x = x + 12
        window_y = y + 12
        Gosu.draw_rect(window_x, window_y, 30, 30, Gosu::Color::YELLOW)
        x += 49
      end
      y += 50
    end

    wid = 30
    len = 40   
    tl_x = top_left_x + width / 2 - wid / 2
    tl_y = 360
    draw_rect(tl_x, tl_y, wid, len, Gosu::Color::RED)
    draw_triangle(tl_x, tl_y + len, Gosu::Color::GREEN,
      tl_x + wid, tl_y + len, Gosu::Color::GREEN, 
      tl_x + wid - 60, tl_y + len + 30, Gosu::Color::GREEN, 
      ZOrder::MIDDLE, mode=:default)
  end

  def draw_street
    draw_rect(0, 400, 500, 30, Gosu::Color.new(220, 50, 50, 2), ZOrder::MIDDLE)
    x = 20
    while x < 500
      draw_line(x, 465, Gosu::Color::WHITE, 
        x + 30, 465, Gosu::Color::WHITE, 
        ZOrder::TOP, mode=:default)
      x += 50
    end
  end

  def update
  end

  def draw
    # draw_curve(0, 200, 300, 0, 300, 200, 600, 200, 2, Gosu::Color::YELLOW, 5)
    moon = Gosu::Image.new(Circle.new(50))
    moon.draw(50, 50, ZOrder::MIDDLE, 1.0, 1.0, Gosu::Color::YELLOW)
    draw_cloud(250, 30)
    draw_cloud(20, 90)
    draw_house(0, 250, 150, 150)
    draw_house(150, 200, 100, 200)
    draw_house(250, 250, 100, 150)
    draw_house(350, 150, 100, 250)
    draw_house(450, 200, 100, 200)
    draw_street()
    end
end

def main
  window = GameWindow.new
  window.show
end

main if __FILE__ == $0

