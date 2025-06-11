let numbers = [];
let numBars = 20; // Number of bars to display
let minVal = 10; // Minimum value for numbers
let maxVal = 100; // Maximum value for numbers

function setup() {
  createCanvas(800, 600);
  generateNumbers(); // Generate initial set of numbers
  sortNumbers(); // Sort numbers initially
  
  noStroke();
}

function draw() {
  background(30); // Dark background for better contrast
  
  // Display the bars
  for(let i = 0; i < numbers.length; i++) {
    let n = numbers[i];
    let x = map(i, 0, numbers.length, 0, width);
    let w = width / numbers.length;
    let h = map(n, 0, maxVal, 0, height);
    let y = height - h;
    
    // Use different color schemes based on index
    let hue, sat, bri;
    if (i % 3 === 0) {
      hue = map(n, minVal, maxVal, 0, 120); // Greenish range
      sat = 80;
      bri = 90;
    } else if (i % 3 === 1) {
      hue = map(n, minVal, maxVal, 120, 240); // Bluish range
      sat = 90;
      bri = 100;
    } else {
      hue = map(n, minVal, maxVal, 240, 360); // Reddish range
      sat = 100;
      bri = 80;
    }
    
    colorMode(HSB, 360, 100, 100);
    fill(hue, sat, bri);
    rect(x, y, w, h);
  }
}

function keyPressed() {
  if (key === 'r' || key === 'R') { // Press 'R' key to reset
    generateNumbers();
    sortNumbers();
  }
}

function generateNumbers() {
  numbers = [];
  for (let i = 0; i < numBars; i++) {
    numbers.push(int(random(minVal, maxVal + 1)));
  }
}

function sortNumbers() {
  numbers.sort(function(a, b) {
    return a - b; // Sort in ascending order
  });
}
