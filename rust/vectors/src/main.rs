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

    let mut s1 = String::from("foo");
    let s2 = "bar";
    s1.push_str(s2); // takes a string slie because we don't want to take ownership of it, i.e.,
                     // can still print s2 below

    let mut s = String::from("lo");
    let v = 'l';
    s.push(v);
    println!("{s}");
    println!("{v}");

    // add takes ownership of s1,
    // it appends a copy of the contents of s2 to s1,
    // and then it returns back ownership of s1.
    let s1 = String::from("Hello, ");
    let s2 = String::from("world!");
    let s3 = s1 + &s2; // note s1 has been moved here and can no longer be used
    println!("{s3}");

    let s1 = String::from("tic");
    let s2 = String::from("tac");
    let s3 = String::from("toe");
    let s = format!("{}-{}-{}", s1, s2, s3);
    println!("{s}")

    // it don't work, can't index strings due to string b eing Vec of bytes, some unicode
    // characters take more than one byte of storage
    // let s1 = String::from("hello");
    // let h = s1[0];
}
