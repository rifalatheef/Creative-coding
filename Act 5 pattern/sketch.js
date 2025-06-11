let img;
let stepSize = 10;

function preload() {
  img = loadImage("yourImage.jpg"); // Replace with your own image
}

function setup() {
  createCanvas(800, 600);
  imageMode(CORNER);
  img.resize(width, height); // Resize image to fit canvas
  background(0);
  noLoop(); // Only draw once unless refreshed
}

function draw() {
  background(0);
  img.loadPixels();

  for (let y = 0; y < height; y += stepSize) {
    for (let x = 0; x < width; x += stepSize) {
      // Get color at x, y from image
      let i = (x + y * width) * 4;
      let r = img.pixels[i];
      let g = img.pixels[i + 1];
      let b = img.pixels[i + 2];
      let brightnessVal = (r + g + b) / 3;

      // Map brightness to rotation and length
      let angle = map(brightnessVal, 0, 255, 0, TWO_PI);
      let len = map(brightnessVal, 0, 255, 2, stepSize);

      // Draw line at x, y with angle and length
      push();
      translate(x, y);
      rotate(angle);
      stroke(r, g, b);
      strokeWeight(2);
      line(-len / 2, 0, len / 2, 0);
      pop();
    }
  }
}




