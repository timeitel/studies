use rand::Rng;
use std::cmp::Ordering;
use std::io;

fn main() {
    println!("Guess the number between 1 and 100\n");

    let secret_number = rand::thread_rng().gen_range(1..=100);

    println!("Enter your guess.");
    loop {
        let mut guess = String::new();

        io::stdin()
            .read_line(&mut guess)
            .expect("Failed to read line");

        let guess: u32 = match guess.trim().parse() {
            Ok(num) => num,
            Err(_) => continue,
        };

        match guess.cmp(&secret_number) {
            Ordering::Less => println!("You guessed: {guess}, that's too small.\nTry Again\n"),
            Ordering::Greater => print!("You guessed: {guess}, that's too large\nTry Again\n"),
            Ordering::Equal => {
                println!("You got it! You did so well");
                break;
            }
        }
    }
}
