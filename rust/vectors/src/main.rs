fn main() {
    let v = vec![1, 2, 3, 4, 5];

    let third: &i32 = &v[2];
    println!("The third element is {}", third);

    let third: Option<&i32> = v.get(2);
    match third {
        Some(third) => println!("The third element is {}", third),
        None => println!("There is no third element."),
    }

    let data = "initial contents".to_string();
    println!("{:?}", data);

    let mut s = String::from("foo");
    s.push_str("bar");
    println!("{s}");
}
