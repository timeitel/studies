trait MakeNoise {
    fn make_noise(&self) {
        println!("(silence)");
    }
}

struct Dog;
struct Cat;

impl MakeNoise for Dog {
    fn make_noise(&self) {
        println!("bark");
    }
}

impl MakeNoise for Cat {}

fn notify(item: &impl MakeNoise) {
    item.make_noise();
}

fn main() {
    let dog = Dog {};
    let cat = Cat {};

    notify(&dog);
    notify(&cat);
}
