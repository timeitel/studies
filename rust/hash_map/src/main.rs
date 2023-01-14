fn main() {
    use std::collections::HashMap;

    let mut scores = HashMap::new();

    scores.insert(String::from("Blue"), 10);
    scores.insert(String::from("Yellow"), 50);

    let team_name = String::from("Blue");
    let score = scores.get(&team_name).copied().unwrap_or(0);
    println!("{score}");

    for (key, value) in &scores {
        println!("{}: {}", key, value);
    }

    scores.entry(String::from("Yellow")).or_insert(1000);
    scores.entry(String::from("Red")).or_insert(50);
    println!("{:?}", scores);

    let mut h = HashMap::new();
    h.insert("k1", 0);
    let v1 = &h["k1"];
    // h.insert("k2", 1);
    // let v2 = &h["k2"];
    // println!("{} {}", v1, v2);

    let mut h: HashMap<char, Vec<usize>> = HashMap::new();
    for (i, c) in "hello!".chars().enumerate() {
        h.entry(c).or_insert(Vec::new()).push(i);
    }
    let mut sum = 0;
    for i in h.get(&'l').unwrap() {
        println!("{i}");
        sum += *i;
    }
    println!("{}", sum);

    // ownership quiz
    fn remove_zeros(v: &mut Vec<i32>) {
        for (i, t) in v.clone().iter().enumerate().rev() {
            if *t == 0 {
                v.remove(i);
            }
        }
    }

    // Reverses the elements of a vector in-place
    fn reverse(v: &mut Vec<String>) {
        let n = v.len();
        for i in 0..n / 2 {
            std::mem::swap(&mut v[i], &mut v[n - i - 1]);
        }
    }
}
