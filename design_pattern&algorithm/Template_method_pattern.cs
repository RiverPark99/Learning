using System;

namespace Template_Method_Pattern
{
    /*
    템블릿 메서드 패턴은 여러 클래스에서 공통으로 사용하는 메서드를 템플릿(변하지 않는것을 의미)화 하여 상위클래스에서 정의하고
    세부 동작을 하위클래스마다 서로 다르게 구현하는 디자인 패턴입니다.

    Console 학습할때 나왔던 캡슐화, 상속, 다형성, 추상화를 다 사용한 
    객체지향 언어의 4대 특성을 전부 활용한 패턴으로 이해했습니다.

    변하지 않는 부모 클래스에서 기능을 만들어두고 자주 변경돼는 기능은 자식 클래스에서 만들어 확장, 상속을 극대화합니다.

    hook() 훅 메소드, 갈고리로 중간에 부모 템플릿 메서드의 영향이나 순서를 제어하고 싶을때 사용하는 메서드 형태를 사용하기도 하는데,
    추상 메서드가 아닌 일반 메서드로 일단 구현해놓고 선택적으로 자식 클래스에서 오버라이드하여 제어하거나, 내버려 두거나 할 수 있습니다.

     */

    abstract class Fatherclass
    {
        protected virtual bool hook() { return true; }//hook 메서드. 이녀석의 값으로 예외처리 겁니다. virtual 메서드로 구현(선택적 오버라이드)

        private void step1() { Console.WriteLine("짐을 내려놓습니다"); } //일반 메서드
        protected abstract void step2();//상속시켜서 작성할 추상 메서드들
        private void step3() { Console.WriteLine("남자 화장실에 갔다 옵니다."); }

        public void Prepareforwork()//오버라이드 불가능한 메서드 이녀석이 템플릿 메서드
        {
            //상속하여 구현되면 실행될 메서드들
            step1();
            step2();
            if (hook())
            {
                step3();
            }
        }
    }

    class Sonclass : Fatherclass // Fatherclass 부모를 상속시킵니다.
    {
        protected override void step2() { Console.WriteLine("출석도장을 찍습니다"); }

    }//이러면 Sonclass 객체를 생성하고 Fatherclass에서 상속받은  Prepareforwork()을 실행하면 step1->step2->step3까지 진행합니다.
    
    
    class Daughterclass : Fatherclass // Fatherclass 부모를 상속시킵니다.
    {
        protected override void step2() { Console.WriteLine("출석도장을 찍습니다"); }
        protected override bool hook() { return false; }//hook virtual 오버라이드
    }//이러면 Daughterclass 객체를 생성하고 Fatherclass에서 상속받은  Prepareforwork()을 실행하면 step1>step2으로 진행합니다.


    class Who_class : Fatherclass
    {
        protected override void step2() { Console.WriteLine("출석도장을 찍습니다"); }
        protected override bool hook() //hook 메서드를 오버라이드 합니다. 흐름도 이런식으로 제어할 수 있습니다.
        {
            string answer = "";
            
            while (true)
            {
                Console.WriteLine("남자면 1을 입력하고 여자면2를 입력하세요");
                answer = Console.ReadLine();
                if (answer.Equals("1"))
                {
                    return true;
                }
                else if (answer.Equals("2"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("잘못 입력했습니다.");
                    continue;
                }
            }
        }

    }//이러면 Who_class 객체를 생성하고 Fatherclass에서 상속받은  Prepareforwork()을 실행하면 step1>step2->hook함수 진행후
     //결과에따라 step3를 진행하거나 진행하지 않습니다.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------");
            Console.WriteLine("Sonclass");
            Fatherclass child = new Sonclass();
            child.Prepareforwork();

            Console.WriteLine("------------");
            Console.WriteLine("Daughterclass");
            child = new Daughterclass();
            child.Prepareforwork();

            Console.WriteLine("------------");
            Console.WriteLine("who_class");
            child = new Who_class();
            child.Prepareforwork();
        }
    }

    //템플릿 메서드 사용시기는
    //자식클래스에서만 특정 단계만 확장시키고, 부모 클래스에서는 구조를 확장하지 않을때
    //동일한 기능은 상위 클래스에서만 정의하면서 확장하면서 변화가 필요한 부분만 하위 클래스에서 구현할때가 있으며

    //이 디자인 패턴의 장점은 하위 클래스의 역할을 줄이고, 핵심 로직을 상위 클래스에서 관리할 수 있게됍니다.

    //단점으로는 상위 클래스가 복잡해질 수록, 추상 메서드가 많아지면서 형태를 유지하기 어려줘지며
    //핵심 로직에 변화가 생겨 상위 클래스를 수정할때, 모든 하위 클래스의 수정이 필요할 수도 있습니다.
    // 리스코프 치환 원칙(부모 클래스의 행동 규약을 자식 클래스가 위반하면 안됌)을 위반할 여지가 있습니다.(자식 클래스에서 자유롭게 오버라이드하면서 위반될 여지)
}
