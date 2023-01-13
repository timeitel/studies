fn main() {
    let mut v = vec![100, 32, 57];
    for n_ref in &v {
        // n_ref has type &i32
        let n_plus_one: i32 = *n_ref + 1;
        println!("{}", n_plus_one);
    }

    println!("\n");

    for n_ref in &mut v {
        // n_ref has type &mut i32
        *n_ref += 50;
        println!("{}", n_ref)
    }
}
