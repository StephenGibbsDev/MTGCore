import { shallowMount } from "@vue/test-utils";
import ManaCost from "../../src/components/ManaCost.vue";

describe("ManaCost.vue", () => {
    const manaCost = "{2}{W}";
    const wrapper = shallowMount(ManaCost, {
        propsData: { manaCost }
    });

    it("renders props.manaCost when passed", () => {
        expect(wrapper.props("manaCost")).toMatch(manaCost);
    });

    it("renders computed.manaArray when passed", () => {
        let array = ["2", "W"];
        expect(wrapper.vm.manaArray).toEqual(array);
    });

    it("renders the images correctly when passed", () => {
        const images = wrapper.findAll("img");
        expect(images.length).toBe(2);
        expect(images.at(0).html()).toMatch('<img src=\"2.svg\" width="20" height="20">');
        expect(images.at(1).html()).toMatch('<img src=\"W.svg\" width="20" height="20">');
    });

    it("test fail", () => {
        expect(1).toBe(2);
    });
});
