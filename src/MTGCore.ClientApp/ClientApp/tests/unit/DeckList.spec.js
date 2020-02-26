import { shallowMount } from "@vue/test-utils";
import DeckList from "../../src/components/DeckList.vue";

describe("ManaCost.vue", () => {
   var deckList = [{ "id":1, "title":"RDW" },{ "id":2, "title":"jank" }];

    const wrapper = shallowMount(DeckList, {
        propsData: { deckList }
    });

    it("should be deckList object", () => {
        expect(wrapper.props("deckList").toString()).toMatch(deckList.toString());
    });

    it("renders 1 as the first id property", () => {
        expect(wrapper.props("deckList")[0].id.toString()).toMatch("1");
    });

    it("renders 'jank' as the second title property", () => {
        expect(wrapper.props("deckList")[1].title.toString()).toMatch("jank");
    });

    it("renders the 2 option correctly when passed", () => {
        const options = wrapper.findAll("option");
        expect(options.length).toBe(2);
    });

    it("renders the RDW option for first value", () => {
        const options = wrapper.findAll("option");
        expect(options.at(0).html()).toMatch('<option key="1">RDW</option>')
    });

    it("renders the jank option for second value", () => {
        const options = wrapper.findAll("option");
        expect(options.at(1).html()).toMatch('<option key="2">jank</option>')
    });

});
